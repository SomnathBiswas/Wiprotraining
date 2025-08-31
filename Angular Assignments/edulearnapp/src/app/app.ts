import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Course } from './model/course.model';
import { CourseDetail } from "./components/course-detail/course-detail";
import { CourseList } from "./components/course-list/course-list";
@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'EduLearn Course Management';
  selectedCourse: Course | null = null;

  onCourseSelected(course: Course): void {
    this.selectedCourse = course;
  }
}