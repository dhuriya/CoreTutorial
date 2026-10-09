export interface Student {
  id: number;
  admissionNumber: string;
  name: string;
  lastName: string | null;
  fatherName: string;
  motherName: string;
  parentPhone: string;
  dob: string;
  gender: string;
  email: string;
  mobile: string;
  address: string;
  classId: string;
  sectionId: string;
  rollNo: string;
  admissionDate: string | null;
  status: string;
  createdDate: string;
  updatedDate: string | null;
}