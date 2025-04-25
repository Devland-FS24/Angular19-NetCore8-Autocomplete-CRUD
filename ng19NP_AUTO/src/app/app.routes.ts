import { Routes } from '@angular/router';
import { EmployeeDataComponent } from './employee-data/employee-data.component';
import { ListItemDataComponent } from './list-item-data/list-item-data.component'

export const routes: Routes = [
    {
        path:'employee-data',
        component: EmployeeDataComponent,
    },
    {
        path:'list-item-data',
        component: ListItemDataComponent,
    },
];




