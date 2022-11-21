import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  clientform: FormGroup;
  submitted: boolean = false;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  ngOnInit() {
    this.clientform = this.fb.group({
      client_id: [null],
      client_name: [null],
      client_lm1: [null],
      client_lm2: [null],
      address: [null],
      email: [null],
      pnumber: [null],
      birthdate: [null],
      password: [null]
    });
  }
  submit() {
    this.submitted = true

    var client_id = this.clientform.value.client_id;
    var client_name = this.clientform.value.client_name;
    var client_lm1 = this.clientform.value.client_lm1;
    var client_lm2 = this.clientform.value.client_lm2;
    var address = this.clientform.value.address;
    var email = this.clientform.value.email;
    var pnumber = this.clientform.value.pnumber;
    var birthdate = this.clientform.value.birthdate;
    var password = this.clientform.value.password;



    const formData = new FormData();

    formData.append('client_id', client_id);
    formData.append('client_name', client_name);
    formData.append('client_lm1', client_lm1);
    formData.append('client_lm2', client_lm2);
    formData.append('address', address);
    formData.append('email', email);
    formData.append('pnumber', pnumber);
    formData.append('birthdate', birthdate);
    formData.append('password', password);
  

    this.http.post<any>('/api/cliente/', formData).subscribe(
      res => {
        console.log("data from server", res)
        let message = res.message
        this.ngOnInit();
      }
    );
  }

}
