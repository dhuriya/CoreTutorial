import { Routes } from '@angular/router';
import { StudentTableComponent } from './student-table/student-table';

export const routes: Routes = [
	{ path: 'students', component: StudentTableComponent },
	{ path: '', pathMatch: 'full', redirectTo: 'students' },
	{ path: '**', redirectTo: 'students' },
];
