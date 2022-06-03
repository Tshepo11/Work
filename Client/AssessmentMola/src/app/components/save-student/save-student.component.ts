import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/interfaces/student';

@Component({
  selector: 'app-save-student',
  templateUrl: './save-student.component.html',
  styleUrls: ['./save-student.component.scss']
})
export class SaveStudentComponent implements OnInit {

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    //call the endpoint to save the student in the db
  }

  studentList(){
    //router to navigate to another page
  }

}
