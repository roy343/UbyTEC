import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { StorageService } from 'src/app/storage.service';

interface Business{
  id: number;
  name: string;
}

@Component({
  selector: 'app-business-list',
  templateUrl: './business-list.component.html',
  styleUrls: ['./business-list.component.css']
})

export class BusinessListComponent implements OnInit {

  business: Business[] = [];

  constructor(private API: APICommunicationService,private route: ActivatedRoute, private router: Router, private local: StorageService) { }

  ngOnInit(): void {

    let routeParams: any = this.route.snapshot.paramMap;
    this.API.getAllBusinessTypes().subscribe(response => {
      this.local.saveData('business', JSON.stringify(response));
    });
    this.business = JSON.parse(this.local.getData('business'));
  }

  handleEdit(id: number) {
    this.router.navigate(['/business-edit', id]);
  }

}
