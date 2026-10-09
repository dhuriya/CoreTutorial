import { Component, computed, ElementRef, OnInit, signal, ViewChild } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { StudentService } from '../services/student';
import { Student } from '../models/student';

@Component({
  selector: 'app-student-table',
  imports: [CommonModule],
  templateUrl: './student-table.html',
  styleUrl: './student-table.css',
})
export class StudentTableComponent implements OnInit{
  @ViewChild('studentDetailsDialog', { static: true })
  private studentDetailsDialog!: ElementRef<HTMLDialogElement>;

  protected readonly students = signal<Student[]>([]);
  protected readonly selectedStudent = signal<Student | null>(null);
  protected readonly loading = signal(false);
  protected readonly errorMessage = signal('');

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.getStudents();
  }

  protected getStudents(): void {
    this.loading.set(true);
    this.errorMessage.set('');

    this.studentService.getAllStudents().subscribe({
      next: (data) => {
        this.students.set(data);
        this.loading.set(false);
      },
      error: (error: HttpErrorResponse) => {
        this.errorMessage.set(error.status === 0
          ? 'Cannot reach the student API through the development proxy. Check that the API on port 5065 is running.'
          : `Student API request failed (HTTP ${error.status}).`);
        this.loading.set(false);
      },
    });
  }

  protected readonly searchTerm = signal('');
  protected readonly statusFilter = signal('All');
  protected readonly statusOptions = computed(() => [
    'All',
    ...new Set(this.students().map((student) => student.status).filter(Boolean)),
  ]);
  protected readonly filteredStudents = computed(() => {
    const query = this.searchTerm().trim().toLowerCase();
    const status = this.statusFilter();

    return this.students().filter((student) => {
      const searchableText = [
        student.name,
        student.lastName,
        student.email,
        student.admissionNumber,
        student.classId,
        student.sectionId,
        student.rollNo,
      ].join(' ').toLowerCase();
      const matchesSearch = !query || searchableText.includes(query);
      const matchesStatus = status === 'All' || student.status === status;

      return matchesSearch && matchesStatus;
    });
  });

  protected studentInitials(student: Student): string {
    return `${student.name.charAt(0)}${student.lastName?.charAt(0) ?? ''}`.toUpperCase();
  }

  protected studentFullName(student: Student): string {
    return [student.name, student.lastName].filter(Boolean).join(' ');
  }

  protected openDetails(student: Student): void {
    this.selectedStudent.set(student);
    this.studentDetailsDialog.nativeElement.showModal();
  }

  protected closeDetails(): void {
    this.studentDetailsDialog.nativeElement.close();
  }

  protected clearSelectedStudent(): void {
    this.selectedStudent.set(null);
  }

  protected closeOnBackdrop(event: MouseEvent): void {
    if (event.target === event.currentTarget) {
      this.closeDetails();
    }
  }

  protected displayValue(value: string | number | null | undefined): string {
    return value === null || value === undefined || value === '' ? 'Not provided' : String(value);
  }
}