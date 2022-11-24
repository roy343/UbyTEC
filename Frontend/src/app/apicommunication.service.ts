import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class APICommunicationService {

  url : String = 'http://localhost:5000/api/'

  constructor(private httpClient: HttpClient) {
  }

  //Gestion empleados
  public getAllEmployees() {
    return this.httpClient.get(this.url + 'administrador');
  }
  public getEmployeeById(id: String) {
    return this.httpClient.get(this.url + 'administrador/cedula/' + id);
  }
  public addEmployee(employee: any) {
    return this.httpClient.post(this.url + 'administrador', employee);
  }
  public updateEmployee(employee: any) {
    return this.httpClient.put(this.url + 'administrador', employee);
  }
  public deleteEmployee(id: String) {
    return this.httpClient.delete(this.url + 'administrador/' + id);
  }
  public getEmployeebyUsername(username: String) {
    return this.httpClient.get(this.url + 'administrador/usuario/' + username);
  }

  //Gestion de afiliados
  public getAllAffiliates() {
    return this.httpClient.get(this.url + 'comercio_afiliado');
  }
  public getAffiliateById(id: String) {
    return this.httpClient.get(this.url + 'comercio_afiliado/cedula/' + id);
  }
  public addAffiliate(affiliate: any) {
    return this.httpClient.post(this.url + 'comercio_afiliado', affiliate);
  }
  public updateAffiliate(affiliate: any) {
    return this.httpClient.put(this.url + 'comercio_afiliado', affiliate);
  }
  public deleteAffiliate(id: String) {
    return this.httpClient.delete(this.url + 'comercio_afiliado/' + id);
  }
  public getAffiliatebyEmail(email: String) {
    return this.httpClient.get(this.url + 'comercio_afiliado/email/' + email);
  }

  //Gestion de Admin de Comercio
  public getAllAdmins() {
    return this.httpClient.get(this.url + 'admin_comercio');
  }
  public getAdminById(id: String) {
    return this.httpClient.get(this.url + 'admin_comercio/cedula/' + id);
  }
  public addAdmin(admin: any) {
    return this.httpClient.post(this.url + 'admin_comercio', admin);
  }
  public updateAdmin(admin: any) {
    return this.httpClient.put(this.url + 'admin_comercio', admin);
  }
  public deleteAdmin(id: String) {
    return this.httpClient.delete(this.url + 'admin_comercio/' + id);
  }
  public getAdminbyUsername(username: String) {
    return this.httpClient.get(this.url + 'admin_comercio/usuario/' + username);
  }
  public getAdminbyEmail(email: String) {
    return this.httpClient.get(this.url + 'admin_comercio/email/' + email);
  }

  //Gestion de Solicitudes de Afiliacion
  public getAllAffiliationRequests() {
    return this.httpClient.get(this.url + 'solicitud_comercio');
  }
  public denyAffiliationRequest(id: String) {
    return this.httpClient.put(this.url + 'solicitud_comercio/deny' + id, null);
  }
  public acceptAffiliationRequest(id: String) {
    return this.httpClient.put(this.url + 'solicitud_comercio/accept' + id, null);
  }

  //Gestion de Tipos de Comercio
  public getAllBusinessTypes() {
    return this.httpClient.get(this.url + 'tipos_comercio');
  }
  public getBusinessTypeById(id: String) {
    return this.httpClient.get(this.url + 'tipos_comercio/id/' + id);
  }
  public getBusinessTypebyName(name: String) {
    return this.httpClient.get(this.url + 'tipos_comercio/nombre/' + name);
  }
  public addBusinessType(businessType: any) {
    return this.httpClient.post(this.url + 'tipos_comercio', businessType);
  }
  public updateBusinessType(businessType: any) {
    return this.httpClient.put(this.url + 'tipos_comercio', businessType);
  }
  public deleteBusinessType(id: String) {
    return this.httpClient.delete(this.url + 'tipos_comercio/' + id);
  }

  //Gestion de repartidores
  public getAllDeliverers() {
    return this.httpClient.get(this.url + 'repartidor');
  }
  public getDelivererById(id: String) {
    return this.httpClient.get(this.url + 'repartidor/cedula/' + id);
  }
  public addDeliverer(deliverer: any) {
    return this.httpClient.post(this.url + 'repartidor', deliverer);
  }
  public updateDeliverer(deliverer: any) {
    return this.httpClient.put(this.url + 'repartidor', deliverer);
  }
  public deleteDeliverer(id: String) {
    return this.httpClient.delete(this.url + 'repartidor/' + id);
  }
  public getDelivererbyUsername(username: String) {
    return this.httpClient.get(this.url + 'repartidor/usuario/' + username);
  }
  public getDelivererbyEmail(email: String) {
    return this.httpClient.get(this.url + 'repartidor/email/' + email);
  }

  //Gestion de clientes
  public getAllClients() {
    return this.httpClient.get(this.url + 'cliente');
  }
  public getClientById(id: String) {
    return this.httpClient.get(this.url + 'cliente/cedula/' + id);
  }
  public addClient(client: any) {
    return this.httpClient.post(this.url + 'cliente', client);
  }
  public updateClient(client: any) {
    return this.httpClient.put(this.url + 'cliente', client);
  }
  public deleteClient(id: String) {
    return this.httpClient.delete(this.url + 'cliente/' + id);
  }
  public getClientbyUsername(username: String) {
    return this.httpClient.get(this.url + 'cliente/usuario/' + username);
  }
  public getClientbyEmail(email: String) {
    return this.httpClient.get(this.url + 'cliente/email/' + email);
  }

  //Reporte Consolidado de ventas
  public getSalesReport() {
    return this.httpClient.get(this.url + 'salesReport');
  }

  //Reporte ventas de afiliados
  public getAffiliateSalesReport() {
    return this.httpClient.get(this.url + 'affiliateSalesReport');
  }
}
