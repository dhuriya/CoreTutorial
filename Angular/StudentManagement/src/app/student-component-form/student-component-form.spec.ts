import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StudentComponentForm } from './student-component-form';

describe('StudentComponentForm', () => {
  let component: StudentComponentForm;
  let fixture: ComponentFixture<StudentComponentForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentComponentForm],
    }).compileComponents();

    fixture = TestBed.createComponent(StudentComponentForm);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
