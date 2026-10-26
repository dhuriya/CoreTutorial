export type TaskPriority = 'low' | 'medium' | 'high';
export interface Task{
  id: string;
  title: string;
  decription: string;
  priority: TaskPriority;
  completed: boolean;
  createdAt: string;
  userId: string
}

// TaskPriority — sirf 3 allowed values, galat value nahi daal sakte
// userId — har user apne tasks dekhe, dusre ke nahi (multi-user support)
// createdAt — sorting ke liye
