import { Routes } from '@angular/router';
import { CartHomeComponent } from './Pages/cart-home/cart-home.component';
import { HomeComponent } from './Pages/LandingPage/home/home.component';
import { PackageEditComponent } from './Pages/Packagess/PackageEdit/package-edit/package-edit.component';
import { PackageAddComponent } from './Pages/Packagess/PackageAdd/package-add/package-add.component';
import { PackageDeleteComponent } from './Pages/Packagess/PackageDelete/package-delete/package-delete.component';
import { PackageListComponent } from './Pages/Packagess/PackageList/package-list/package-list.component';
import { AboutUsComponent } from './Pages/LandingPage/about-us/about-us.component';

export const routes: Routes = [
    { path: 'Cart/:userId', component: CartHomeComponent },
    { path: 'Package', component:PackageListComponent,title:"Packages" },
    {path:'Package/delete/:id',component:PackageDeleteComponent,title:'Delete'},
    {path:'Package/add',component:PackageAddComponent,title:'Add'},
    {path:'Package/edit/:id',component:PackageEditComponent,title:'Edit'},
    {path: 'Home', component: HomeComponent, title:'Home', children:[
        {path:'About',component:AboutUsComponent,title:'About'},
    ]},
    {path: '', redirectTo: 'Home', pathMatch: "full"}
];
