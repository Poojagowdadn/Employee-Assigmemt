import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class EmployeeServiceService {
  constructor(private http: HttpClient) {}

  private EmployeeData: string = environment.baseUrl + 'Employee/';

  addUpdateEmployee(record: Employee): Observable<Employee> {
    return this.http.post<Employee>(
      this.EmployeeData + 'addUpdateEmployee',
      record
    );
  }

  AllEmployeeList(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.EmployeeData + 'AllEmployeeList');
  }

  EmployeeRecordDelete(id: any): Observable<any> {
    const param = new HttpParams().set('id', id);
    return this.http.delete(this.EmployeeData + 'EmployeeRecordDelete', {
      params: param,
    });
  }

}
