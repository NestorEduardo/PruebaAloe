import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Subject } from "rxjs";
import { Injectable } from "@angular/core";
import { Department } from "../models/department";
import { error } from "protractor";

@Injectable()
export class DepartmentService {
  departmentsSubject: Subject<Array<Department>>;

  constructor(private httpClient: HttpClient) {
    this.departmentsSubject = new BehaviorSubject<Array<Department>>([]);
  }

  public getAll() {
    this._getAll();
    console.log(this._getAll());
    return this.departmentsSubject.asObservable();
  }

  public create(department: Department) {
    return this._create(department);
  }

  public update(department: Department) {
    return this._update(department);
  }

  public getById(id: number) {
    return this._getById(id);
  }

  private _getAll() {
    return this.httpClient.get<Array<Department>>("api/Department/GetAll")
      .subscribe(departments => this.departmentsSubject.next(departments), error => this.departmentsSubject.error(error));
  }

  private _create(department: Department) {
    debugger;
    return this.httpClient.post('api/Department/Add', department);
  }

  private _update(department: Department) {
    return this.httpClient.post('api/Department/Update', department);
  }

  private _getById(id: number) {
    return this.httpClient.get<Department>(`api/Department/GetById/${id}`);
  }

  public delete(department: Department) {
    return this.httpClient.post('api/Department/Delete', department);
  }
}
