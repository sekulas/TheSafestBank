import { Link } from "react-router-dom";

const ErrorPage = () => {

  return (
    <div id="error-page">
      <h1>Oops! 404 Not found.</h1>
      <Link to="/">Go back to the home page.</Link>
    </div>
  );

}

export default ErrorPage;