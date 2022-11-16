import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AfProductComponent } from './af-product.component';

describe('AfProductComponent', () => {
  let component: AfProductComponent;
  let fixture: ComponentFixture<AfProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AfProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AfProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
