import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Student } from '../models/student';

interface ApiStudent {
	id: number;
	admission_number: string;
	name: string;
	lastname: string | null;
	fatherName: string;
	motherName: string;
	parentPhone?: string | null;
	patentPhone?: string | null;
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

@Injectable({ providedIn: 'root' })
export class StudentService {
	private readonly http = inject(HttpClient);
	private readonly apiUrl = '/api/Student/GetAll';

	getAllStudents(): Observable<Student[]> {
		return this.http.get<ApiStudent[]>(this.apiUrl).pipe(
			map((students) => students.map((student) => ({
				id: student.id,
				admissionNumber: student.admission_number,
				name: student.name,
				lastName: student.lastname,
				fatherName: student.fatherName,
				motherName: student.motherName,
				parentPhone: student.parentPhone ?? student.patentPhone ?? '',
				dob: student.dob,
				gender: student.gender,
				email: student.email,
				mobile: student.mobile,
				address: student.address,
				classId: student.classId,
				sectionId: student.sectionId,
				rollNo: student.rollNo,
				admissionDate: student.admissionDate,
				status: student.status,
				createdDate: student.createdDate,
				updatedDate: student.updatedDate,
			}))),
		);
	}
}
