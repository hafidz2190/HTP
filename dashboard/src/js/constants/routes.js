import Loadable from 'react-loadable'
import Loading from '../components/common/Loading'

// <PrivateRoute authed={this.props.appState.login.username !== ''} path="/adjustment" component={AdjustmentPage} />

const AsyncDashboard = Loadable({
        loader: () => import("../components/DashboardPage"),
        loading: Loading
    }),
    AsyncProfile = Loadable({
        loader: () => import("../components/ProfilePage"),
        loading: Loading
    }),
    AsyncInformationPage = Loadable({
        loader: () => import("../components/InformationPage"),
        loading: Loading
    }),
    AsyncAdjustmentPage = Loadable({
        loader: () => import("../components/AdjustmentPage"),
        loading: Loading
    }),
    AsyncGeneratePaymentPage = Loadable({
        loader: () => import("../components/GeneratePaymentPage"),
        loading: Loading
    })

const Routes = [
    {
        path: "/",
        component: AsyncDashboard
    },
    {
        path: "/profile",
        component: AsyncProfile
    },
    {
        path: "/information",
        component: AsyncInformationPage
    },
    {
        path: "/adjustment",
        component: AsyncAdjustmentPage
    },
    {
        path: "/generate-payment",
        component: AsyncGeneratePaymentPage
    }
]

export { Routes }