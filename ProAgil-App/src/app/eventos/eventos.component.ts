import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: any;

  constructor(private client: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {

    this.client.get('http://localhost:5000/api/evento')
      .subscribe(res => {
        this.eventos = res;
      }, error => {
        console.log(error);
      });

  }
}
