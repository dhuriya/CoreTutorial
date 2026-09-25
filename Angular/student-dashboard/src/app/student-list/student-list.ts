import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';   // 👈 saare pipes isme
import { FormsModule } from '@angular/forms';
import { Student } from '../models/student';
import { StudentCount } from '../student-count/student-count';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [
    CommonModule,      // DatePipe, UpperCasePipe, CurrencyPipe sab isme
    FormsModule,
    StudentCount
  ],
  templateUrl: './student-list.html',
  styleUrls: ['./student-list.css']
})
export class StudentList {
  selectedStudentCountRadioButton: string = 'All';

  students: Student[] = [
    { ID: 'std101', FisrtName: 'Pranaya',  LastName: 'Rout',      DOB: new Date(1988, 11, 8), Gender: 'Male',   CourseFee: 1234.56 },
    { ID: 'std102', FisrtName: 'Anurag',   LastName: 'Mohanty',   DOB: new Date(1989,  9,14), Gender: 'Male',   CourseFee: 6666.00 },
    { ID: 'std103', FisrtName: 'Priyanka', LastName: 'Dewangan',  DOB: new Date(1992,  6,24), Gender: 'Female', CourseFee: 6543.15 },
    { ID: 'std104', FisrtName: 'Hina',     LastName: 'Sharma',    DOB: new Date(1990,  7,19), Gender: 'Female', CourseFee: 9000.50 },
    { ID: 'std105', FisrtName: 'Sambit',   LastName: 'Satapathy', DOB: new Date(1991,  3,12), Gender: 'Male',   CourseFee: 9876.54 },
  ];

  getTotalStudentCount(): number {
    return this.students.length;
  }

  getMaleStudentCount(): number {
    return this.students.filter(s => s.Gender === 'Male').length;
  }

  getFemaleStudentCount(): number {
    return this.students.filter(s => s.Gender === 'Female').length;
  }

  onStudentCountRadioButtonChange(selectedRadioButtonValue: string): void {
    this.selectedStudentCountRadioButton = selectedRadioButtonValue;
  }

  trackById = (_: number, s: Student) => s.ID;

  formatDob(dob: Date): string {
    const day = String(dob.getDate()).padStart(2, '0');
    const month = String(dob.getMonth() + 1).padStart(2, '0');
    const year = dob.getFullYear();
    return `${day}/${month}/${year}`;
  }
}