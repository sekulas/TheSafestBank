import { useContext } from "react";
import AuthContext from "../features/auth/context/AuthContext";

const ClientDetailsPage = () => {
  const { name, surname, clientNumber, identityCard, email, address } = useContext(AuthContext)
  return (
    <div id="client-details-page">

      <div id="client-details">
        <div>
          <p>NAME AND SURNAME</p>
          <h1>{name} {surname}</h1>
        </div>
        <div>
          <p>CLIENT NUMBER</p>
          <h1>{clientNumber}</h1>
        </div>
      </div>

      <div id="client-identity-card-details">
        <div>
          <h2>IDENTITY CARD DETAILS</h2>
          <p>TYPE AND SERIE</p>
          <h1>{identityCard.type}</h1>
          <h1>{identityCard.serie} {identityCard.number}</h1>
        </div>
        <div>
          <p>COUNTRY OF ISSUE</p>
          <h1>{identityCard.countryOfIssue}</h1>
        </div>

      </div>

      <div id="client-contact-details">
        <div>
          <h2>CONTACT</h2>
          <p>E-MAIL</p>
          <h1>{email}</h1>
        </div>
      </div>

      <div id="client-address-details">
        <div>
          <h2>ADDRESS</h2>
          <p>ADRESS OF RESIDENCE</p>
          <h1>{address.street} {address.houseNumber}, {address.zipCode}, {address.city}, {address.country}</h1>
        </div>
      </div>

    </div>
  );
}
export default ClientDetailsPage;