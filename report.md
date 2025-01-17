# Image processing: Assignment 2

## Choices Made

- In the case of a binary image, a pixel with value 0 is 'off', all the other pixels [1-255] are 'on'. When performing an operation that returns a binary image (instead of a greyscale image) the values 0 and 255 will strictly be used (and no values in between).

- We have added two possible shapes for the structuring element, namely a cross and a square. Using a element size of 3, these shapes correspond to a 4-neighborhood and 8-neighborhood respectively. The shapes are implemented as an `Int[,]` where indices with value 0 are ignored in morphological operations.

- The boundary trace function is implemented using the Moore tracing function. First the 'first pixel' is found by scanning the image, starting from the top left corner in a row first manner. After the first pixel is found the boundary is traced by looking in the 8-neighborhood for adjacent pixels. The stopping criterion is encountering the first pixel, not the first pixel in combination with the direction. Therefore some complex shapes are not traced correctly. This function also only draws the first encountered shape and does not include enclosed shapes. This first encountered shape is than drawn as a bitmap and also written to the output window (View->Output / Ctrl + Alt + O).

## Images X,Y,Z

![Image X](results\image_x.bmp){height=33.3333%}

![Image Y](results\image_y.bmp){height=33.3333%}

![Image Z](results\image_z.bmp){height=33.3333%}

We obtain image Z as follows from image W (assignment 1) using a square, 3x3 structuring element H:
$$
Z = W \oplus H \cap \overline{W \ominus H}
$$
The image Z we obtain is then the union of the outline of image W and the outline of image X. 


## Images E1,E2,E3,E4,E5


| Image Name                   | A    | E1   | E2   | E3   | E4   | E5   |
| ---------------------------- | ---- | ---- | ---- | ---- | ---- | ---- |
| **Structuring element size** | N.A  | 3    | 5    | 7    | 9    | 11   |
| **# of values**              | 255  | 250  | 248  | 246  | 244  | 244  |

Table: Number of distinct pixel values of image before and after dilations with structuring element with square shape and increasing size.

After applying a dilation, we see a decrease in distinct pixel values in the image. Greyscale dilation is defined on an image $I$ and structuring element $H$ as follows:
$$
(I \oplus H) (u,v) = \max_{(i,j) \in H} \{I(u+i,v+j) + H(i,j)\}
$$
Since this maximum value can be the same in two neighbouring subimages of $I$, two adjacent pixels of different pixel values can end up with the same value. If for example a white pixel is surrounded by a variety of lower valued pixels, these surrounding pixels will all become white as a result of the dilation. This in turn can lead to a loss in the number of pixel values used. Because we take the maximum pixel values can only stay the same or become higher, so this loss will almost entirely be in the lower end of the spectrum.

![Log Histogram of image E5, a loss of lower intensity values and overexposure are evident.](assets\1569674635664.png)

## Images G1...Gn

![Image G1](results\g1.bmp){height=33.3333%}

![Image G2](results\g2.bmp){height=33.3333%}

![Image G3](results\g3.bmp){height=33.3333%}

![Image G4](results\g4.bmp){height=33.3333%}

![Image G5](results\g5.bmp){height=33.3333%}

When plotting the results which are displayed in the table above you can see it takes the form of the following function:
$$
y(x) = d - c x^2
$$
Where $x,c > 0$. This can be explained due to the way the morphological filter works.  It takes the minimum/ maximum in the given area, defined by the kernel size. For a given pixel that has a local minimum/ maximum this value will propagate to all adjacent pixels within the kernel size $x$, this will effect $x^2$ pixels.

|                        | **Original** | **G1** | **G2** | **G3** | **G4** | **G5** |
| ---------------------- | ------------ | ------ | ------ | ------ | ------ | ------ |
| **Kernel size**        | N.A          | 3      | 23     | 43     | 63     | 83     |
| **unique pixel count** | 255          | 254    | 253    | 246    | 206    | 47     |

Table:  Number of non-background values of image before and after dilations with structuring element with square shape and increasing size.
