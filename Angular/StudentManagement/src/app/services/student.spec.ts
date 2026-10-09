import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { StudentService } from './student';

describe('StudentService', () => {
  let service: StudentService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient(), provideHttpClientTesting()],
    });
    service = TestBed.inject(StudentService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('loads students from the API', () => {
    service.getAllStudents().subscribe((students) => {
      expect(students).toEqual([{
        id: 1,
        admissionNumber: 'ADM-001',
        name: 'Rahul',
        lastName: 'Sharma',
        fatherName: 'Amit Sharma',
        motherName: 'Priya Sharma',
        parentPhone: '1234567890',
        dob: '2010-05-15',
        gender: 'M',
        email: 'rahul@example.com',
        mobile: '9876501234',
        address: 'Gurugram',
        classId: 'CLS001',
        sectionId: 'SEC01',
        rollNo: '101',
        admissionDate: '2026-04-01',
        status: 'False',
        createdDate: '2026-10-09',
        updatedDate: null,
      }]);
    });

    const request = httpTestingController.expectOne('/api/Student/GetAll');
    expect(request.request.method).toBe('GET');
    request.flush([{
      id: 1,
      admission_number: 'ADM-001',
      name: 'Rahul',
      lastname: 'Sharma',
      fatherName: 'Amit Sharma',
      motherName: 'Priya Sharma',
      patentPhone: '1234567890',
      dob: '2010-05-15',
      gender: 'M',
      email: 'rahul@example.com',
      mobile: '9876501234',
      address: 'Gurugram',
      classId: 'CLS001',
      sectionId: 'SEC01',
      rollNo: '101',
      admissionDate: '2026-04-01',
      status: 'False',
      createdDate: '2026-10-09',
      updatedDate: null,
    }]);
  });
});
