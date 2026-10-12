import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { StudentService } from '../services/student';

@Component({
  imports: [FormsModule, CommonModule],
  selector: 'app-student-component-form',
  styleUrl: './student-component-form.css',
  templateUrl: './student-component-form.html',
})
export class StudentComponentForm {
  constructor(private studentService: StudentService) {}
  student ={
    name: '',
    lastname: '',
    fatherName: '',
    motherName: '',
    patentPhone: '',
    dob: '',
    gender: '',
    email: '',
    mobile: '',
    address: '',
    classId: '',
    sectionId: '',
    rollNo: '',
    admissionDate: '',
    status: '',
    createdDate: '',
    updatedDate: ''
  };
  onSubmit(form: NgForm) {
    if (form.invalid) {
      form.control.markAllAsTouched();
      return;
    }

    const currentDate = new Date().toISOString();

    const studentData = {
      admission_number: this.generateAdmissionNumber(),
      ...this.student,
      sectionId: 'A',
      rollNo: this.generateRollNo(),
      admissionDate: currentDate,
      status: 'N',
      createdDate: currentDate
    };
    console.log('Student Data:', studentData);
    this.studentService.addStudent(studentData).subscribe({
      next: (response) => {
        console.log('Student saved successfully:', response);
        alert('Student added successfully!');
        form.resetForm();
      },
      error: (error) => {
        console.error('Error saving student:', error);
        alert('Student save nahi hua. Please try again.');
      }
    });
  }
  generateAdmissionNumber(): string {
    return 'ADM' + Date.now();
  }
  generateRollNo(): string{
    return String(Date.now());
  }
}
