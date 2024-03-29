import React, { useEffect, useState } from 'react';
//import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { createStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

import { ProductResult } from "../services/IShop/Products";
import { getProducts } from "../services/IShop/Products";


const useStyles = makeStyles(theme =>
    createStyles({
    cardGrid: {
        paddingTop: theme.spacing(8),
        paddingBottom: theme.spacing(8),
    },
    card: {
        height: '100%',
        display: 'flex',
        flexDirection: 'column',
    },
    cardMedia: {
        paddingTop: '56.25%', // 16:9
    },
    cardContent: {
        flexGrow: 1,
    }
    })
);

const CardGridContainer = () => {
    // call service here
    const [result, setResult] = useState<ProductResult>();
    useEffect(() => {
        getProducts("toy", "").then((response) => {
          setResult(response);
        });
      }, []);

    const cards = result ? result.products : []; // [1, 2, 3, 4, 5, 6, 7, 8, 9];
    const classes = useStyles();
    
    return <Container className={classes.cardGrid} maxWidth="md">
        <div>Result: {JSON.stringify(result)}</div>
        <Grid container spacing={4}>
            {cards.map(card => (
                <Grid item key={card.id} xs={12} sm={6} md={4}>
                    <Card className={classes.card}>
                        <CardMedia
                            className={classes.cardMedia}
                            image="https://source.unsplash.com/random"
                            title={card.category.name + " - " + card.category.description}
                        />
                        <CardContent className={classes.cardContent}>
                            <Typography gutterBottom variant="h5" component="h2">
                                {card.name}
                            </Typography>
                            <Typography>
                                {card.description}
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Button size="small" color="primary">
                                Add to Cart
                            </Button>
                        </CardActions>
                    </Card>
                </Grid>
            ))}
        </Grid>
    </Container>;
}

class Products extends React.PureComponent {
    public render() {
        return (
            <React.Fragment>
                <CssBaseline />
                <main>
                    <CardGridContainer />
                </main>
            </React.Fragment>
        );
    }
};

export default Products;
