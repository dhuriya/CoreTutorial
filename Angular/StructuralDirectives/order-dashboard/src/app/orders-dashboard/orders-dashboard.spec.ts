import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OrdersDashboard } from './orders-dashboard';

describe('OrdersDashboard', () => {
  let component: OrdersDashboard;
  let fixture: ComponentFixture<OrdersDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrdersDashboard],
    }).compileComponents();

    fixture = TestBed.createComponent(OrdersDashboard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render order rows and filter by customer name', () => {
    const native = fixture.nativeElement as HTMLElement;
    expect(native.textContent).toContain('Ravi Kumar');

    component.searchText = 'anita';
    fixture.detectChanges();

    expect(native.textContent).toContain('Anita Das');
    expect(native.textContent).not.toContain('Ravi Kumar');
  });
});
