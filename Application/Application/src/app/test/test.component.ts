import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  test: string;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.onGetContent();
  }

  onGetContent() {
    var url = "https://localhost:44327/Values/GetContents"
    this.http.get(url).subscribe(data => {
      this.test = data[0];
    })
  }
}
