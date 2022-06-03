import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/interfaces/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-display-student',
  templateUrl: './display-student.component.html',
  styleUrls: ['./display-student.component.scss']
})
export class DisplayStudentComponent implements OnInit {

  constructor(private studentService: StudentService, private router: Router) { }

  ngOnInit(): void {
  }

}
