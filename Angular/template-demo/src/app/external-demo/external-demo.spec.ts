import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ExternalDemo } from './external-demo';

describe('ExternalDemo', () => {
  let component: ExternalDemo;
  let fixture: ComponentFixture<ExternalDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExternalDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(ExternalDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
