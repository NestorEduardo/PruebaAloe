import { Component, OnInit } from '@angular/core';
import { Department } from '../models/department';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-home',
  templateUrl: './departments.component.html',
})

export class DepartmentsComponent implements OnInit {
  departments: Array<Department> = [];

  constructor(private departmentService: DepartmentService) {
  }


  ngOnInit() {
    this.departmentService.getAll().subscribe(
      departments => {
        this.departments = this.departments
        console.log(this.departments);
      },
      error => alert(error),
      () => console.log('Request completed')
    );
  }
}
