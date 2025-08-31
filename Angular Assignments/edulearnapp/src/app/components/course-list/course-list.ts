import { Component, EventEmitter, Output } from '@angular/core';
import { Course } from '../../model/course.model';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
  standalone: false

})
export class CourseList {

  @Output() courseSelected = new EventEmitter<Course>();

  courses: Course[] = [
    {
      id: 1,
      title: 'Angular Fundamentals',
      description: 'Learn the basics of Angular framework',
      instructor: 'John Doe',
      duration: '8 weeks',
      level: 'Beginner',
      price: 299
    },
    {
      id: 2,
      title: 'Advanced TypeScript',
      description: 'Master TypeScript for enterprise applications',
      instructor: 'Jane Smith',
      duration: '6 weeks',
      level: 'Advanced',
      price: 399
    },
    {
      id: 3,
      title: 'React Basics',
      description: 'Introduction to React library',
      instructor: 'Mike Johnson',
      duration: '5 weeks',
      level: 'Beginner',
      price: 249
    },
    {
      id: 4,
      title: 'Node.js Backend Development',
      description: 'Build scalable backend applications',
      instructor: 'Sarah Wilson',
      duration: '10 weeks',
      level: 'Intermediate',
      price: 449
    }
  ];
  selectCourse(course: Course): void {
    this.courseSelected.emit(course);
  }

}
