import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogComponentDialogComponent } from './dialog-content.component';

describe('DialogComponentDialogComponent', () => {
  let component: DialogComponentDialogComponent;
  let fixture: ComponentFixture<DialogComponentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogComponentDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogComponentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
