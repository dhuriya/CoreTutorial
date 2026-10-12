import { Routes } from '@angular/router';
import { StudentTableComponent } from './student-table/student-table';
import { StudentComponentForm } from './student-component-form/student-component-form';

export const routes: Routes = [
	{ path: 'students', component: StudentTableComponent },
	{path: 'student-from', component: StudentComponentForm},
	{ path: '', pathMatch: 'full', redirectTo: 'students' },
	{ path: '**', redirectTo: 'students' }
];
