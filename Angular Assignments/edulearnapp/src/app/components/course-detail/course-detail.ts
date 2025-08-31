import { Component, Input } from '@angular/core';
import { Course } from '../../model/course.model';
@Component({
  selector: 'app-course-detail',
  standalone: false,  
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.css'
})
export class CourseDetail {
  @Input() selectedCourse: Course | null = null;

  editableTitle: string = '';

  ngOnChanges(): void {
    if (this.selectedCourse) {
      this.editableTitle = this.selectedCourse.title;
    }
  }


  updateCourseTitle(): void {
    if (this.selectedCourse && this.editableTitle.trim()) {
      this.selectedCourse.title = this.editableTitle.trim();
    }
  }


}
