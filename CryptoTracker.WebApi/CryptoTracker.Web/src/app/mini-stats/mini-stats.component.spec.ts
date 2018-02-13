import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MiniStatsComponent } from './mini-stats.component';

describe('MiniStatsComponent', () => {
  let component: MiniStatsComponent;
  let fixture: ComponentFixture<MiniStatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MiniStatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MiniStatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
