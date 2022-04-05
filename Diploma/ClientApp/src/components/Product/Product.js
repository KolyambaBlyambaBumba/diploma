function Product(props) {
    const { name, description } = props.product;
    return (
      <div>
          <div>Имя: {name}</div>
          <div>Описание: {description}</div>
      </div>
    );
}

export default Product;