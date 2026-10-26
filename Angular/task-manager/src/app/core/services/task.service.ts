import { Injectable, signal, computed, inject } from "@angular/core";
import { Task, TaskPriority } from '../models/task.model'
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private readonly STORAGE_KEY = 'tm_tasks';
  private authService = inject(AuthService);

  // Signal - reactive state
  private tasksSignal = signal<Task[]>(this.loadTasks());

  // Public readonly - components ise read karenge;
  readonly tasks = this.tasksSignal.asReadonly();

  // Computed - auto-update jab tasks change hon
  readonly totalCount = computed(() => this.tasks().length);
  readonly completedCount = computed(() =>
      this.tasks().filter(t => t.completed).length
  );
  readonly pendingCount = computed(() =>
    this.tasks().filter(t => !t.completed).length
  );
  //----------------CREATE---------------------
  addTask(title: string, decription: string, priority: TaskPriority): void{
    const  user = this.authService.currentUser();
    if(!user) return;

    const newTask: Task = {
      id: crypto.randomUUID(),
      title,
      decription,
      priority,
      completed: false,
      createdAt: new Date().toISOString(),
      userId: user.id
    };
    this.tasksSignal.update(tasks => [...tasks, newTask]);
    this.saveTasks();
  }
  //------------------- Update------------------------
  updateTask(id: string,updates: Partial<Task>): void{
    this.tasksSignal.update(tasks =>
      tasks.map(t => t.id === id ? {...t,...updates}: t)
    );
    this.saveTasks();
  }
  //------------------- TOGGLE COMPLETE ----------------
  toggleComplete(id: string): void{
    this.tasksSignal.update(tasks => tasks.map(t => t.id === id? {...t, computed: !t.completed} : t));
    this.saveTasks();
  }
  //-------------- DELETE ----------------------------
  deleteTask(id: string): void{
    this.tasksSignal.update(tasks => tasks.filter(t => t.id !== id));
    this.saveTasks();
  }
  // READ (Current user Tasks)
  getTasksForCurrentUser(): Task[]{
    const user = this.authService.currentUser();
    if(!user) return[];
    return this.tasks().filter(t => t.userId === user.id);
  }
  // ------------------- PERSISTENCE ---------------------
  private loadTasks(): Task[]{
    const raw = localStorage.getItem(this.STORAGE_KEY);
    return raw ? JSON.parse(raw) : [];
  }
  private saveTasks(): void{
    localStorage.setItem(this.STORAGE_KEY, JSON.stringify(this.tasksSignal()));
  }
}

// Part	                                                       Kyu
// signal<Task[]>(...)	                        Reactive state — jab bhi tasks badlenge, UI auto-update hogi
// asReadonly()	                                Components ko sirf read karne do, direct modify na kar sakein — encapsulation
// computed()	                                  Derived values — completedCount auto-recalculate hoga jab tasks change ho
// tasksSignal.update(fn)	                      Signal ki value update karne ka safe way (immutable updates)
// [...tasks, newTask]	                        Naya array banao — immutability (signals ko detect karne ke liye)
// Partial<Task>	                              Update ke time sirf kuch fields dena — TypeScript flexible
// userId filter	                              Multi-user — har user apne tasks dekhe
// loadTasks() / saveTasks()	                  localStorage persistence — refresh ke baad bhi tasks rahenge
