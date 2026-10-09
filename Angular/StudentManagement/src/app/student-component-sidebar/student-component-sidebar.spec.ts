import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { StudentComponentSidebar } from './student-component-sidebar';

describe('StudentComponentSidebar', () => {
  let component: StudentComponentSidebar;
  let fixture: ComponentFixture<StudentComponentSidebar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentComponentSidebar],
      providers: [provideRouter([])],
    }).compileComponents();

    fixture = TestBed.createComponent(StudentComponentSidebar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
