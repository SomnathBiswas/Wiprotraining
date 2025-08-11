import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignalMenu } from './signal-menu';

describe('SignalMenu', () => {
  let component: SignalMenu;
  let fixture: ComponentFixture<SignalMenu>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SignalMenu]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignalMenu);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
