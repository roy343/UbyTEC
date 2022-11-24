import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { StorageService } from 'src/app/storage.service';

interface Affiliate {
  id: number;
  name: string;
  email: string;
  phone: string;
  province: string;
  canton: string;
  district: string;
  businessType: string;
  adminId: number;
}

@Component({
  selector: 'app-affiliate-list',
  templateUrl: './affiliate-list.component.html',
  styleUrls: ['./affiliate-list.component.css']
})
export class AffiliateListComponent implements OnInit {

  affiliates: Affiliate[] = [];

  constructor(private API: APICommunicationService,private route: ActivatedRoute, private router: Router, private local: StorageService) {
  }

  ngOnInit(): void {

    let routeParams: any = this.route.snapshot.paramMap;
    this.API.getAllAffiliates().subscribe(response => {
      this.local.saveData('affiliates', JSON.stringify(response));
    });
    this.affiliates = JSON.parse(this.local.getData('affiliates'));
  }

  handleEdit(id: number) {
    this.router.navigate(['/affiliate-edit', id]);
  }

}
