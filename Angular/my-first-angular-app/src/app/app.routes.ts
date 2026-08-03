import { Routes } from '@angular/router';
import { Home } from './home/home'
import { Product } from './product/product'
import { About } from './about/about'
export const routes: Routes = [
  {path: '',component:Home},
  {path:'product',component:Product},
  {path:'about',component:About}
];
