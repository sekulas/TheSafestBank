import { useContext } from "react";
import AuthContext from "../features/auth/context/AuthContext";
import ShowHideComponent from "../features/showing-info/ShowHideComponent";

const ClientDetailsPage = () => {
  const { name, surname, clientNumber, identityCard, email, address } = useContext(AuthContext)
  return (
    <div id="client-details-page">

      <div id="client-details">
        <div>
          <h2>CLIENT DATA</h2>
          <h5>NAME AND SURNAME</h5>
          <p>{name} {surname}</p>
        </div>
        <div>
          <h5>CLIENT NUMBER</h5>
          <ShowHideComponent>
            {clientNumber}
          </ShowHideComponent>
        </div>
      </div>

      <div id="client-identity-card-details">
        <div>
          <h2>IDENTITY CARD DETAILS</h2>
          <h5>TYPE AND SERIE</h5>
          <p>{identityCard.type}</p>
          <ShowHideComponent>
            {identityCard.serie} {identityCard.number}
          </ShowHideComponent>
        </div>
        <div>
          <h5>COUNTRY OF ISSUE</h5>
          <p>{identityCard.countryOfIssue}</p>
        </div>

      </div>

      <div id="client-contact-details">
        <div>
          <h2>CONTACT</h2>
          <h5>E-MAIL</h5>
          <ShowHideComponent>
            {email}
          </ShowHideComponent>
        </div>
      </div>

      <div id="client-address-details">
        <div>
          <h2>ADDRESS</h2>
          <h5>ADRESS OF RESIDENCE</h5>
          <ShowHideComponent>
            {address.street} {address.houseNumber}, {address.zipCode}, {address.city}, {address.country}
          </ShowHideComponent>
        </div>
      </div>

    </div>
  );
}
export default ClientDetailsPage;