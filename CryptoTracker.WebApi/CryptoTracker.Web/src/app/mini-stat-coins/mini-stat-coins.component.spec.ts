import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MiniStatCoinsComponent } from './mini-stat-coins.component';

describe('MiniStatCoinsComponent', () => {
  let component: MiniStatCoinsComponent;
  let fixture: ComponentFixture<MiniStatCoinsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MiniStatCoinsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MiniStatCoinsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
