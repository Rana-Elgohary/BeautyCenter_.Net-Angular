import { Routes } from '@angular/router';
import { CartHomeComponent } from './Pages/cart-home/cart-home.component';
import { PackageListComponent } from './Pages/Packages/PackageList/package-list/package-list.component';
import { PackageDeleteComponent } from './Pages/Packages/PackageDelete/package-delete/package-delete.component';
import { PackageAddComponent } from './Pages/Packages/PackageAdd/package-add/package-add.component';
import { PackageEditComponent } from './Pages/Packages/PackageEdit/package-edit/package-edit.component';
import { HomeComponent } from './Pages/LandingPage/home/home.component';

export const routes: Routes = [
    { path: 'Cart/:userId', component: CartHomeComponent },
    { path: 'Package', component:PackageListComponent,title:"Packages" },
    {path:'Package/delete/:id',component:PackageDeleteComponent,title:'Delete'},
    {path:'Package/add',component:PackageAddComponent,title:'Add'},
    {path:'Package/edit/:id',component:PackageEditComponent,title:'Edit'},
    {path:'**', component:HomeComponent}
];
