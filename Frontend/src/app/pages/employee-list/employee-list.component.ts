import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { StorageService } from 'src/app/storage.service';

interface Employee {
  id: number;
  name: string;
  email: string;
  phone: string;
  province: string;
  canton: string;
  district: string;
  username: string;
  password: string;
}
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [];

  constructor(private API: APICommunicationService,private route: ActivatedRoute, private router: Router, private local: StorageService) { }

  ngOnInit(): void {

    let routeParams: any = this.route.snapshot.paramMap;
    this.API.getAllEmployees().subscribe(response => {
      this.local.saveData('employees', JSON.stringify(response));
    });
    this.employees = JSON.parse(this.local.getData('employees'));
  }

  handleEdit(id: number) {
    this.router.navigate(['/employee-edit', id]);
  }

}
