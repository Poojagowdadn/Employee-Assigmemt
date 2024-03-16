import { Component, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { Employee } from './employee.model';
import { EmployeeServiceService } from './employee-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})

export class AppComponent {

  vcEmpCategory: any;
  record: Employee = {};
  EmployeeDataRecord: Employee[] = [];
  selectedRecord: Employee = {};

  constructor(
    private spinner: NgxSpinnerService,
    private Api: EmployeeServiceService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.GetRecords();
  }

  GetRecords() {
    this.Api.AllEmployeeList().subscribe({
      next: (data: Employee[]) => {
        this.spinner.hide();
        this.EmployeeDataRecord = data;
      },
      error: (err) => {
        console.log(err);
        this.messageService.add({
          key: 'Employee',
          severity: 'error',
          summary: 'Error',
          detail: 'No Record found',
        });
      },
    });
  }

  saveEmployee() {
    this.Api.addUpdateEmployee(this.record).subscribe({
      next: (data: any) => {
        this.GetRecords();
        this.clearEmployee();
        this.messageService.add({
          key: 'Employee',
          severity: 'success',
          summary: 'Successful',
          detail: 'Employee Record Saved',
          life: 3000,
        });
      },
      error: (err) => {
        console.log(err);
        this.messageService.add({
          key: 'Employee',
          severity: 'error',
          summary: 'Error',
          detail: err.error.Message,
        });
      },
    });
  }

  deleteEmployee() {
    this.Api.EmployeeRecordDelete(this.record.ID).subscribe({
      next: (data) => {
        this.spinner.hide();
        this.GetRecords();
        this.clearEmployee();
        this.messageService.add({
          key: 'Employee',
          severity: 'success',
          summary: 'Successful',
          detail: 'Employee Record Deleted',
          life: 3000,
        });
      },
      error: (err) => {
        this.spinner.hide();
        this.messageService.add({
          key: 'Employee',
          severity: 'error',
          summary: 'Error',
          detail: err.error.Message,
        });
      },
    });
  }

  clearEmployee() {
    this.record = {};
  }

  onRowSelect() {
    this.record = this.selectedRecord;
  }
}
