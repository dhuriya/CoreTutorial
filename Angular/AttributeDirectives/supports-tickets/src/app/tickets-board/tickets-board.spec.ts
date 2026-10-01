import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TicketsBoard } from './tickets-board';

describe('TicketsBoard', () => {
  let component: TicketsBoard;
  let fixture: ComponentFixture<TicketsBoard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TicketsBoard],
    }).compileComponents();

    fixture = TestBed.createComponent(TicketsBoard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
