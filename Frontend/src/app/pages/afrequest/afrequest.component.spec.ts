import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AfrequestComponent } from './afrequest.component';

describe('AfrequestComponent', () => {
  let component: AfrequestComponent;
  let fixture: ComponentFixture<AfrequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AfrequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AfrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
