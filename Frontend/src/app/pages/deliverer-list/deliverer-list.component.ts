import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { StorageService } from 'src/app/storage.service';

interface Deliverer {
  name: string;
  email: string;
  province: string;
  canton: string;
  district: string;
  phone: string;
  password: string;
  username: string;
}

@Component({
  selector: 'app-deliverer-list',
  templateUrl: './deliverer-list.component.html',
  styleUrls: ['./deliverer-list.component.css']
})
export class DelivererListComponent implements OnInit {

  deliverers: Deliverer[] = [];

  constructor(private API: APICommunicationService,private route: ActivatedRoute, private router: Router, private local: StorageService) { }

  ngOnInit(): void {

    let routeParams: any = this.route.snapshot.paramMap;
    this.API.getAllDeliverers().subscribe(response => {
      this.local.saveData('deliverers', JSON.stringify(response));
    });
    this.deliverers = JSON.parse(this.local.getData('deliverers'));
  }

  handleEdit(id: number) {
    this.router.navigate(['/deliverer-edit', id]);
  }

}
