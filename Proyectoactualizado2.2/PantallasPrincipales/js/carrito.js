window.onload = function() {
	 $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/Carrito/ProductosValorCarritoCliente?clienteID="+localStorage.getItem("clienteID"),

        dataType: "json",
		 success: function(data) {
			 var precio = document.getElementById("precio");
			 precio.innerHTML="TOTAL: "+"$"+data.valorcarrito;
			 $.each(data.productos, function(i, item) { 
			 
			        var tr= document.createElement('tr');
					var td= document.createElement('td');
					
					var div= document.createElement('div');
					div.className="contenedor-imagen";
					
					var imagen = document.createElement('IMG');
					imagen.src= 'images/'+item.imagen;
					imagen.id=item.productoID;
					
				
					
					div.append(imagen);
					td.append(div);
					tr.append(td);
					
					
					var td1= document.createElement('td');
					td1.className="titulo";
					td1.innerHTML=item.nombre;
					var td2= document.createElement('td');
					td2.className="precio";
					td2.textContent="$"+item.precio;
					var td3= document.createElement('td');
					td3.className="cantidad";
					var texto="unidades";
					if(item.cantidad==1){
						texto="unidad";
					}
					td3.textContent=item.cantidad+" "+texto;
					var td4= document.createElement('td');
					td4.className="centrar-boton";
					
					
					var a= document.createElement('button');
					a.className="btn btn-danger centrar-boton";
					a.textContent="Borrar";
					
					a.onclick= function()
					{
						$.ajax({
                                    type: "GET",
                                         url: "https://localhost:44310/api/Carrito/BorrarProductoCarrito?productoID="+item.productoID+"&carritoID="+localStorage.getItem("carritoID"),
										 dataType: "json",
		                                 success: function(data) {
											 
											 var precio = document.getElementById("precio");
			                                 precio.innerHTML=  precio.innerHTML-item.precio;
											 location.reload();
											 
		                                                        }
										 
										 
										  });
					}
					
					td4.append(a);
					tr.append(td1);
					tr.append(td2);
					tr.append(td3);
					tr.append(td4);
					
					
					
					$('#contenedor').append(tr);
			 
			  });
			 
		 },
		  error: function(error) {
            console.log(error.message);
            alert('error');
        }
	
	
	
		
	 });
	
	
	
	
}


function cancelar()
{
	
	$.ajax({
                                    type: "GET",
                                         url: "https://localhost:44310/api/Carrito/BorrarCarritoCompleto?carritoID="+localStorage.getItem("carritoID"),
										 dataType: "json",
		                                 success: function(data) {
											 
											 
											 location.reload();
											 
		                                                        }
										 
										 
										  });
	
	
}