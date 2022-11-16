import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AfOrderComponent } from './af-order.component';

describe('AfOrderComponent', () => {
  let component: AfOrderComponent;
  let fixture: ComponentFixture<AfOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AfOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AfOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
