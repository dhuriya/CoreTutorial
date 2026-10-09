import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Orders } from './orders';

describe('Orders', () => {
  let component: Orders;
  let fixture: ComponentFixture<Orders>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Orders],
    }).compileComponents();

    fixture = TestBed.createComponent(Orders);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should suggest matching orders as the user types', () => {
    component.searchText.set('alex');

    expect(component.filteredSuggestions().length).toBeGreaterThan(0);
    expect(component.filteredSuggestions()[0]).toContain('Alex');
  });
});
