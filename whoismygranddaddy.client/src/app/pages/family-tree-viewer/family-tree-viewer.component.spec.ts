import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyTreeViewerComponent } from './family-tree-viewer.component';

describe('FamilyTreeViewerComponent', () => {
  let component: FamilyTreeViewerComponent;
  let fixture: ComponentFixture<FamilyTreeViewerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FamilyTreeViewerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FamilyTreeViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
