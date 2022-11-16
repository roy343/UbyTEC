import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AfloginComponent } from './aflogin.component';

describe('AfloginComponent', () => {
  let component: AfloginComponent;
  let fixture: ComponentFixture<AfloginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AfloginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AfloginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
