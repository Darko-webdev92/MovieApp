import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesByUserComponent } from './movies-by-user.component';

describe('MoviesByUserComponent', () => {
  let component: MoviesByUserComponent;
  let fixture: ComponentFixture<MoviesByUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoviesByUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviesByUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
