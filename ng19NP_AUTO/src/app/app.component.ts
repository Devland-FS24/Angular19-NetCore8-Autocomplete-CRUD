import { Component } from '@angular/core';
//import { RouterOutlet } from '@angular/router';
import { ListItemDataComponent } from './list-item-data/list-item-data.component';

@Component({
  selector: 'app-root',
  imports: [ListItemDataComponent],
  //imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular_19_employee_app';

  getNotification(evt: any) {
     // Event Emitter demo: PARENT GETS NOTIFICATION FROM CHILD
    //console.log('THIS IS EVT VALUE: ' + evt)
}


}
