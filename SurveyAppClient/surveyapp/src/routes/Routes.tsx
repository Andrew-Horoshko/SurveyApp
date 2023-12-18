import {Route, Switch, Redirect} from 'react-router-dom';
import { PlacePage, HomePage, AccountPage, DoctorPage, StrategyPage, AdminPage, UserManualPage } from '../pages';
import { SignInPage } from '../pages/SignInPage/SignInPage';
import CompletedSurveysPage from '../pages/CompletedSurveysPage/CompletedSurveysPage';

const Routes = () => {
    return (
        <Switch>
            <Route exact path="/" component={() => <Redirect to='/home'/>}/>
            <Route path="/account" render={() => <AccountPage/>}/>
            <Route path="/place/:id" render={() => <PlacePage/>}/>
            <Route path="/home" render={() => <HomePage/>}/>
            <Route path="/sign-in" render={()=><SignInPage/>} />
            <Route path="/completed-surveys" render={()=><CompletedSurveysPage/>} />
            <Route path="/strategy" render={()=><StrategyPage/>} />
            <Route path="/users/doctor" render={()=><DoctorPage/>} />
            <Route path="/users/admin" render={()=><AdminPage/>} />
            <Route path="/user-manual" render={()=><UserManualPage/>} />
        </Switch>
    );
};

export default Routes;
