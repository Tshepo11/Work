import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayStudentComponent } from './components/display-student/display-student.component';
import { SaveStudentComponent } from './components/save-student/save-student.component';

const routes: Routes = [
  { path: 'saveStudent',component: SaveStudentComponent},
  { path: 'StudentList', component: DisplayStudentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
